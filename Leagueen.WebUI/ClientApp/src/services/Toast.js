import React from "react";
import { toast, Slide, ToastContainer } from 'react-toastify';
import { func } from 'prop-types';

class ToastService {};

ToastService.info = (msg) => toast.info(msg, getDefaultOptions());
ToastService.success = (msg) => toast.success(msg, getDefaultOptions());
ToastService.warning = (msg) => toast.warn(msg, getDefaultOptions());
ToastService.error = (msg) => toast.error(msg, getDefaultOptions());
ToastService.default = (msg) => toast(msg, getDefaultOptions());

function getDefaultOptions() {
    return {
        position: "bottom-right",
        hideProgressBar: true,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: false
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