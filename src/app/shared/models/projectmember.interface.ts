export interface ProjectMember {
    id: number;
    userID: number;
    avatarPath: string;
    userName: string;
    teamID: number;
    teamName: string;
    roleID: number;
    roleName: string;
    joinedOn: Date;
    addBy: number;
    delFlag: boolean;
}
