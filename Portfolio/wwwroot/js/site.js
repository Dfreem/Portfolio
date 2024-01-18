'use strict';


export function getStylesheets(exclusionPrefix = '__') {
    let sheets = [];
    let stylesheets = document.styleSheets;
    for (let rule of stylesheets) {
        if (!rule.href.includes('bootstrap')) {
            for (let i = 0; i < rule.cssRules.length; i++) {
                if (!rule.cssRules[i].cssText.includes(exclusionPrefix)) {
                    sheets.push(rule.cssRules[i].cssText);
                }
            }
        }
    }
    return sheets;
}

export async function downloadCssFromStream(fileName, contentStreamReference) {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}

export function initTooltips() {
    let tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));
    window.addEventListener('show.bs.tooltip', (e) => {
        let cancelToken = setTimeout(() => {
            const target = document.getElementById(e.target['id']);
            bootstrap.Tooltip.getInstance(target).hide();
        }, 3000);
        window.addEventListener('hide.bs.tooltip', () => {
            clearTimeout(cancelToken);
        });
    });
}

export function initToast() {
    const toastElList = document.querySelectorAll('.toast');
    [...toastElList].map(toastEl => new bootstrap.Toast(toastEl));

}

export function resetTooltip(id) {
    const selector = `[data-bs-toggle='tooltip']#${id}`;
    let tt = bootstrap.Tooltip.getInstance(selector);
    tt.hide();
    tt.dispose();
    const parent = document.querySelector(selector);
    tt = new bootstrap.Tooltip(parent);


}

export function getHTMLElementIds() {
    const elements = document.querySelectorAll('[id]');
    let ids = Array.from(elements).map(element => element.id);
    ids = ids.filter(e => !e.includes('__'));
    return ids;
};

export function transformById(elementId, transformString) {
    const toMove = document.getElementById(elementId);
    toMove.style.transformOrigin = "0 0 0";
    toMove.style.transform = transformString;

}

export function switchTabs(from, to) {

    document.getElementById(from).classList.add('collapse');
    document.getElementById(`${from}-button`).classList.remove('active');
    document.getElementById(to).classList.remove('collapse');
    document.getElementById(`${to}-button`).classList.add('active');
}

export function resetTabs() {
    $('__transformer-button').addClass("active");
    $('__display-css-button').removeClass("active");
    $('__transformer').removeClass("collapse");
    $('__display-css').addClass("collapse");
}



export function getElementsTransform(id) {
    const target = document.getElementById(id);
    return window.getComputedStyle(target).transform;

}


export function setSliderThumb(id, value) {
    const slider = document.getElementById(id);
    slider.nodeValue = value;
}

export async function showShell() {
    const shell = document.getElementById('__shell');
    shell.classList.toggle('hide-shell');
    let tt = bootstrap.Tooltip.getInstance('[data-bs-toggle="tooltip"]#__transformer-collapse');
    tt.hide();
    tt.dispose();
    const collapseBtn = document.querySelector('[data-bs-toggle="tooltip"]#__transformer-collapse');
    tt = new bootstrap.Tooltip(collapseBtn);
}

export function showExampleObject() {
    document.getElementById('example-object').classList.toggle('visually-hidden');
}
