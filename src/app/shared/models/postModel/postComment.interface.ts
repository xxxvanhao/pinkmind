export interface postComment {
    content: string;
    createBy: number;
    createAt: Date;
    delFlag: boolean;
    updateBy: number;
    fileName: string;
    issueID: string;
}