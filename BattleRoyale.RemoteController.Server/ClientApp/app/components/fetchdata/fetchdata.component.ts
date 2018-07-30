import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from "@angular/router";
import { Client } from "../../models/Client";
import { ClientService } from '../../services/client.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public clients: Client[] | undefined;
    public clientsRetrieved: boolean | null = false;

    constructor(http: Http,
        private router: Router,
        @Inject('BASE_URL') baseUrl: string,
        private clientService: ClientService 
    ) {
        this.clientService.getConnectedClients().subscribe(clients => {
            this.clients = clients as Client[];
            this.clientsRetrieved = true;
        }, error => {
            console.error(error);
            this.clientsRetrieved = null;
        });
    }

    navigateToCommandLine(ipAddress: string) {
        this.clientService.setCurrentClientIPAddress(ipAddress);
        this.router.navigate(["command"]);
    }

    navigateToCommandAll() {
        this.clientService.setCurrentClientIPAddress("");
        this.router.navigate(["commandall"]);
    }

}