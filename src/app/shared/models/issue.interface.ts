export interface Issue {
    message: string;
    issueTypeID: number;
    subject: string;
    description: string;
    statusID: number;
    assigneeUser: number;
    priorityID: number;
    categoryID: number;
    milestoneID: number;
    versionID: number;
    resolutionID: number;
    dueDate: Date;
    projectID: string;
}
