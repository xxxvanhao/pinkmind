export interface IIssueType {
    id: number;
    name: string;
    backgroundColor: string;
    createBy: number;
    createAt: Date;
    updateBy: number;
    lastUpdate: Date;
    delFlag: boolean;
    checkUpdate: string;
}
