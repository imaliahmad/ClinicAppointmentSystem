const notyf = new Notyf({
    duration: 3000,
    position: {
        x: 'right',
        y: 'top',
    },
    types: [
        {
            type: 'warning',
            background: 'orange',
            dismissible: true
        },
        {
            type: 'error',
            background: 'indianred',
            dismissible: true
        },
        
        {
            type: 'success',
            background: 'green',
            dismissible: true
        },
        {
            type: 'info',
            background: 'blue',
            dismissible: true
        },

    ]
});