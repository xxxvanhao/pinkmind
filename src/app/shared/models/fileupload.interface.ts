export interface FileUpload {
    id?: string;
    folderPath: string;
    filePath: string;
    fileSize?: string;
    typeModel?: string;
    imagePath?: string;
    createBy?: number;
    createAt?: Date;
    updateBy?: number;
    lastUpdate?: Date;
    delFlag?: boolean;
    projectID: string;
}
