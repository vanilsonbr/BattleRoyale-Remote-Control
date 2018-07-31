import { Component, Inject, QueryList, ViewChildren } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/Client';
import { CommandComponent } from '../command/command.component';

@Component({
    selector: 'commandall',
    templateUrl: './commandall.component.html',
    styleUrls: ['./commandall.component.css']
})

export class CommandAllComponent {
    clients: Client[];
    commandToAll: string = "";

    @ViewChildren("cmdComp") components: QueryList<CommandComponent>;

    constructor(private clientService: ClientService) {
        this.clients = [];  

        this.clientService.getConnectedClients().subscribe(allClients => {
            this.clients = allClients;
        });


    }

    sendCommandAll() {
        if (this.commandToAll) {
            if (this.components) {
                this.components.forEach(item => {
                    item.sendMessage(this.commandToAll);
                });
            }
        } else {
            // alerta de erro
        }
        this.commandToAll = "";
    }
}