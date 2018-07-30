export enum MessageType {
    server,
    client
}

export interface CommandMessage {
    message: string;
    messageType: MessageType;
}