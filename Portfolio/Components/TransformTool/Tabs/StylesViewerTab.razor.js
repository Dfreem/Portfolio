

export function copyCssToClipboard() {
    let copyText = document.getElementById('__copy-css').innerText;
    navigator.clipboard.writeText(copyText).then(
        () => {
            return true;
        },
        () => {
            return false;
        });
}