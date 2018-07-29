import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'command',
    templateUrl: './command.component.html',
    styleUrls: ['./command.component.css']
})
export class CommandComponent {
    public textInputMessage: string = "";
    public connectionMessage: string = "Connection to Client...";
    public connected: boolean = false;
    public messages: Array<CommandMessage>;
    public clientUrl: string = "";
    private subscriber : any = null;

    constructor(private http: Http, private route: ActivatedRoute) {
        this.messages = [];
    }

    ngOnInit() {
        this.subscriber = this.route.params.subscribe(params => {
            this.clientUrl = params['ipAddress'];
            this.clientUrl = "http://" + this.clientUrl + "/";

            this.initCommandLine();

        })
    }

    ngOnDestroy() {
        this.subscriber.unsubscribe();
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

enum MessageType {
    server,
    client
}

interface CommandMessage {
    message: string;
    messageType: MessageType;
}

interface CommandResult {
    WorkingDirectory: string;
    Result: string;
    CommandSent: string;
    Error: string
    Success: boolean;
}