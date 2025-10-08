import Swal from 'sweetalert2'

export function useAlert() {
    const showAlert = async (options) => {
        return await Swal.fire(options)
    }

    const showSuccess = async (message) => {
        return await showAlert({
        icon: 'success',
        title: message,
        showConfirmButton: false,
        timer: 1500,
        })
    }

    const showError = async (message) => {
        return await showAlert({
        icon: 'error',
        title: message,
        showConfirmButton: false,
        timer: 1500,
        })
    }

    const showConfirm = async (message) => {
        return await showAlert({
        title: 'Are you sure?',
        text: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3eb489',
        cancelButtonColor: '#ff8800',
        confirmButtonText: 'Yes, delete it!',
        })
    }

    return { showError, showSuccess, showConfirm }
}