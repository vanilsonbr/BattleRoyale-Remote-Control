import { Antivirus } from "./Antivirus";
import { WindowsSpecs } from "./WindowsSpecs";
import { HardDriveInformation } from "./HardDriveInformation";

export interface Client {
    machineName: string;
    localIPAddress: string;
    installedAntivirus: Antivirus;
    isFirewallActivated: boolean;
    windowsSpecs: WindowsSpecs;
    installedDotNetVersion: string;
    hardDriveInformation: HardDriveInformation[];
}
