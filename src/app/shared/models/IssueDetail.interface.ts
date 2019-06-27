export interface Issues{

ID : number;
IssueTypeID  : number;
Subject : string;
Description  : string;
StatusID : number;
AssigneeUser : string;
PriorityID : number;
CategoryID : number;
MilestoneID  : number;
VersionID : number;
ResolutionID : number;
DueDate  : Date;
ProjectID : number;
CreateBy  : Date;
CreateAt : string;
UpdateBy  : number;
LastUpdate : Date;
DelFlag : boolean;
}