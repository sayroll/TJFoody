﻿import Data from "../../modules/data.js?v=7.7.0"
import Viewer from "../../modules/viewer.js?v=7.7.0"

export function init(id, prevList) {
    const el = document.getElementById(id)
    if (el === null) {
        return
    }

    const viewer = {
        el,
        viewer: Viewer.init(el, prevList)
    }
    Data.set(id, viewer)
}

export function update(id, prevList) {
    const viewer = Data.get(id)
    viewer.viewer.prevList = prevList
}

export function dispose(id) {
    const viewer = Data.get(id)
    Data.remove(id)

    if (viewer) {
        Viewer.dispose(viewer.viewer)
    }
}
