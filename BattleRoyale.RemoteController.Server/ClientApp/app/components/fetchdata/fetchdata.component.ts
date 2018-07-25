import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public clients: Client[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/RemoteControl/ConnectedClients').subscribe(result => {
            this.clients = result.json() as Client[];
        }, error => console.error(error));
    }
}

interface Antivirus {
    name: string;
    version: string;
    vendor: string;
}

interface WindowsSpecs {
    version: string;
    servicePack: string;
}

interface HardDriveInformation {
    totalSize: string;
    availableSize: string;
}

interface Client {
    machineName: string;
    localIPAddress: string;
    installedAntivirus: Antivirus;
    isFirewallActivated: boolean;
    windowsSpecs: WindowsSpecs;
    installedDotNetVersion: string;
    hardDriveInformation: HardDriveInformation;
}
