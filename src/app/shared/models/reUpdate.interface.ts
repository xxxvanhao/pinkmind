export interface ReUpdate {
    id?: number;
    avatarPath?: string;
    userName?: string;
    actionName: string;
    issueKey: string;
    subject?: string;
    content?: string;
    updateTime?: Date;
    spaceID: string;
    projectKey: string;
}
