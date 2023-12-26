
export function toast(toastClass = "") {
    let toastElement = document.getElementById('__toast');
    if (toastClass !== "") {
        toast.classList.add(toastClass);

    }
    let toast = bootstrap.Toast.getOrCreateInstance(toastElement);
    toast.show()
}


export function toastSuccess() {
    toast("toast-success");
}

export function toastDanger() {
    toast("toast-error");
}