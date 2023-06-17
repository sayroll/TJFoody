﻿import { isDisabled } from "../../modules/utility.js?v=7.7.0"
import Data from "../../modules/data.js?v=7.7.0"
import Popover from "../../modules/base-popover.js?v=7.7.0"
import EventHandler from "../../modules/event-handler.js?v=7.7.0"

export function init(id, invoke, callback) {
    const el = document.getElementById(id)

    if (el == null) {
        return
    }

    const popover = Popover.init(el, {
        itemsElement: el.querySelector('.multi-select-items'),
        closeButtonSelector: '.multi-select-close'
    })

    const ms = {
        el, invoke, callback,
        itemsElement: el.querySelector('.multi-select-items'),
        closeButtonSelector: '.multi-select-close',
        popover
    }

    if (!ms.popover.isPopover) {
        EventHandler.on(ms.itemsElement, 'click', ms.closeButtonSelector, () => {
            const dropdown = bootstrap.Dropdown.getInstance(popover.toggleElement)
            if (dropdown && dropdown._isShown()) {
                dropdown.hide()
            }
        })
    }
    ms.popover.clickToggle = e => {
        const element = e.target.closest(ms.closeButtonSelector);
        if (element) {
            e.stopPropagation()

            invoke.invokeMethodAsync(callback, element.getAttribute('data-bb-val'))
        }
    }
    ms.popover.isDisabled = () => {
        return isDisabled(ms.popover.toggleElement)
    }

    Data.set(id, ms)
}

export function dispose(id) {
    const ms = Data.get(id)
    Data.remove(id)

    if (!ms.popover.isPopover) {
        EventHandler.off(ms.itemsElement, 'click', ms.closeButtonSelector)
    }
    Popover.dispose(ms.popover)
}
