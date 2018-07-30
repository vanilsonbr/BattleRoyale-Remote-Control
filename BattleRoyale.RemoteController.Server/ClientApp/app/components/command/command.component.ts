import { Component, Input, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { CommandResult } from '../../models/CommandResult';
import { CommandMessage, MessageType } from '../../models/CommandMessage';
import { Client } from '../../models/Client';
import { ClientService } from '../../services/client.service';

@Component({
    selector: 'command',
    templateUrl: './command.component.html',
    styleUrls: ['./command.component.css']
})
export class CommandComponent implements OnInit {


    public textInputMessage: string = "";
    public connectionMessage: string = "Connection to Client...";
    public connected: boolean | null = false;
    public messages: CommandMessage[];
    public clientUrl: string = "";
    private subscriber : any = null;

    @Input() client: Client | null;

    constructor(private http: Http, private clientService : ClientService) {
        this.messages = [];
        this.client = null;
    }

    ngOnInit(): void {
        // if the client service has a client selected, I will execute commands only for that client
        var ipAddress: string | null = this.clientService.getCurrentClientIpAddress();

        if (ipAddress) {
            this.clientService.getClient(ipAddress).subscribe(result => {
                this.client = result as Client;
                this.clientUrl = "http://" + result.localIPAddress + "/";
                this.initCommandLine();
            }, error => {
                console.error(error);
                this.connected = null;
            });
        } else {
            // it means that i'm in the commandAll screen and will execute command to all the machines connected
            // meaning that the parent component passed the client via Input
            if (this.client == null) {
                // but if the client is not defined, it is an error.
                this.connected = null;

            } else {
                this.clientUrl = "http://" + this.client.localIPAddress + "/";
                this.initCommandLine();
            }
        }
    }

    initCommandLine() {
        // send handshake message to check connectivity
        // after handshake ok, display the message "client connected and ready";
        this.http.get(this.clientUrl + 'handshake').subscribe(result => {
            if (result) {
                var commandMessage: CommandMessage = {
                    message: "Client connected and ready",
                    messageType: MessageType.server
                }

                this.messages.push(commandMessage);
                this.connected = true;
            }
        }, error => {
            console.error(error);
            this.connectionMessage = "Client disconnected!";
        });
    }

    public sendMessage() {

        var command = this.textInputMessage ? this.textInputMessage.trim() : "";

        if (command) {
            var uriCommand: string = this.clientUrl + "receivecommand";

            this.http.post(uriCommand, command).subscribe(result => {
                if (result && result.ok) {
                    var commandResult = result.json() as CommandResult;

                    var commandServer: CommandMessage = {
                        message: this.textInputMessage,
                        messageType: MessageType.server
                    }
                    var commandClient: CommandMessage;

                    //if (commandResult && commandResult.Success) {
                        commandClient = {
                            message: commandResult.WorkingDirectory + "> " + commandResult.CommandSent + commandResult.Result,
                            messageType: MessageType.client
                        };
                    //} else {
                    //    commandClient = {
                    //        message: commandResult.WorkingDirectory + "> " + commandResult.Error,
                    //        messageType: MessageType.client
                    //    };
                    //}

                    this.messages.push(commandServer);
                    this.messages.push(commandClient);
                    this.textInputMessage = "";
                }
            }, error => console.error(error));
        }

    }
}