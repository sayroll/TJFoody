﻿import Data from "../../modules/data.js?v=7.7.0"

export function init(id, invoker, callback) {
    const handler = e => {
        invoker.invokeMethodAsync(callback, e.data)
    }
    Data.set(id, handler)

    window.addEventListener('message', handler)
}

export function execute(id, data) {
    const frame = document.getElementById(id)
    if (frame) {
        frame.onload = () => {
            frame.contentWindow.postMessage(data)
        }
    }
}

export function dispose(id) {
    const handler = Data.get(id)
    Data.remove(id)

    if (handler) {
        window.removeEventListener('message', handler);
    }
}
