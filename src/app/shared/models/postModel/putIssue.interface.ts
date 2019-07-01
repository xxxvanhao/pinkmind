export interface putIssue{
    id:number;
    issueTypeID: number;
    subject: string;
    description: number;
    statusID: number;
    assigneeUser: number;
    priorityID: number;
    categoryID: number;
    milestoneID: number;
    versionID: number;
    resolutionID: number;
    dueDate: number;
    updateBy: number;
    lastUpdate: number;
    delFlag: number;
}