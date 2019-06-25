export interface Project {
    id: string;
    name: string;
    createBy: number;
    createAt: Date;
    updateBy: number;
    lastUpdate: Date;
    delFlag: boolean;
    checkUpdate?: string;
}