import { Component, Inject } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { Client } from '../../models/Client';

@Component({
    selector: 'commandall',
    templateUrl: './commandall.component.html',
    styleUrls: ['./commandall.component.css']
})

export class CommandAllComponent {
    clients: Client[];

    constructor(private clientService: ClientService) {
        this.clients = [];

        this.clientService.getConnectedClients().subscribe(allClients => {
            this.clients = allClients;
        });


    }
}