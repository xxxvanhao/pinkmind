export interface Notify {
    id?: number;
    status: boolean;
    issueID: number;
    avatarPath?: string;
    userName?: string;
    actionName: string;
    issueKey: string;
    subject?: string;
    content?: string;
    updateTime?: Date;
    projectKey: string;
    spaceID: string;
}
