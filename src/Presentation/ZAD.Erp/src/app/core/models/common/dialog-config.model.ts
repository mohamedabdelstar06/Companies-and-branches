import { DynamicDialogConfig } from "primeng/dynamicdialog";

export interface AlertDialogConfigModel extends DynamicDialogConfig {
    data: AlertDialogDataModel
}

export interface AlertDialogDataModel {
    message: string;
    confirmButtonText?: string;
    cancelButtonText?: string;
    type?: string;
    iconClass?: string;
    onConfirm?: (inputValue?: string) => void;
    onCancel?: () => void;
    showInput?: boolean;
    inputValue?: string;
}
