export interface FileUpload {
    id?: string;
    folderPath: string;
    filePath: string;
    fileSize?: string;
    typeModel?: string;
    imagePath?: string;
    createBy?: number;
    createName?: string;
    createAt?: Date;
    updateBy?: number;
    UpdateName?: string;
    lastUpdate?: Date;
    delFlag?: boolean;
    projectID: string;
}
