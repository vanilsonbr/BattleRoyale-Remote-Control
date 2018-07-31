import { Injectable } from "@angular/core";
import { Http } from "@angular/http"
import { Client } from "../models/Client";
import { Inject } from "@angular/core";
import "rxjs/Rx";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ClientService {
    currentClientIPAddressSelected: string | null;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.currentClientIPAddressSelected = null;
    }

    setCurrentClientIPAddress(currentClientIPAddress: string) {
        this.currentClientIPAddressSelected = currentClientIPAddress;
    }

    getCurrentClientIpAddress(): string | null {
        return this.currentClientIPAddressSelected;
    }

    getClient(clientIpAddress: string): Observable<Client> {
        var url = this.baseUrl + 'api/RemoteControl/GetClient?ipAddress=' + clientIpAddress;

        return this.http.get(url).map(result => {
            var client: Client = result.json() as Client;
            return client;
        });
    }

    getConnectedClients(): Observable<Client[]> {
        var url = this.baseUrl + 'api/RemoteControl/ConnectedClients/';

        return this.http.get(url).map(result => {
            var clients: Client[] = result.json() as Client[];
            return clients;
        });
    }

    handshake(clientIpAddress: string): Observable<boolean> {
        var url = "http://" + clientIpAddress + "/handshake";

        return this.http.get(url).map(result => {
            var r: boolean = result.json() as boolean;
            return r;
        });
    }
}