export interface commentDetail{
    id : number;
    content :string;
    createBy :number;
    createAt :Date;
    updateBy : number;
    lastUpdate: Date;
    delFlag : boolean;
    checkUpdate: string;
    issueID : number;
}