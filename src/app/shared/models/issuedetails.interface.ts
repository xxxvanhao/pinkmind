export interface IssueDetails {
    id: number;
    key: string;
<<<<<<< HEAD
    issueTypeName: string;
    issueTypeColor: string;
=======
>>>>>>> 63f8031a5dae5ec055e6b79561033b2aef1b01e9
    issueTypeID: number;
    subject: string;
    description: string;
    statusID: number;
    statusName: string;
    assigneeUser: number;
    assigneeName: string;
    assigneePicture: string;
    priorityID: number;
    priorityName: string;
    categoryID: number;
    categoryName: string;
    milestoneID: number;
    milestonName: string;
    versionID: number;
    versionName: string;
    resolutionID: number;
    resolutionName: string;
    dueDate: Date;
    projectID: string;
    createBy: number;
    createByName: string;
    createByPicture: string;
    registerName: string;
    createAt: Date;
    updateBy: number;
    updateByName: string;
    updateByPicture: string;
    lastUpdate: Date;
    delFlag: boolean;
    checkUpdate: string;
}
