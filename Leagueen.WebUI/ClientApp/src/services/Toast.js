import React from "react";
import { toast, Slide, ToastContainer } from 'react-toastify';

class ToastService {};

ToastService.info = (msg) => toast.info(msg, getDefaultOptions("toast-info"));
ToastService.success = (msg) => toast.success(msg, getDefaultOptions("toast-success"));
ToastService.warning = (msg) => toast.warn(msg, getDefaultOptions("toast-warn"));
ToastService.error = (msg) => toast.error(msg, getDefaultOptions("toast-error"));
ToastService.show = (msg) => toast(msg, getDefaultOptions("toast-default"));

function getDefaultOptions(className) {
    return {
        position: "bottom-right",
        hideProgressBar: true,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: false,
        className: className
    };
}

function ToastComponent() {

    return (
        <>
            <ToastContainer transition={Slide} newestOnTop/>
        </>
    );
};

export { ToastService, ToastComponent };