export interface IssueDetail{

id : number;
issueTypeID  : number;
subject : string;
description  : string;
statusID : number;
assigneeUser : string;
priorityID : number;
categoryID : number;
milestoneID  : number;
versionID : number;
resolutionID : number;
dueDate  : Date;
projectID : string;
createBy  : number;
createAt : Date;
updateBy  : number;
lastUpdate : Date;
delFlag : boolean;
checkUpdate: string;
}