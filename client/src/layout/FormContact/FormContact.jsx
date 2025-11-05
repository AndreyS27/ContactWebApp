

const FormContact = (props) => {
    return (
        <div>
            <div className="mb-3">
                <form >
                    <div className="mb-3">
                        <label className="form-lablel">Введите имя:</label>
                        <input className="form-control" type="text"/>
                    </div>
                    <div className="mb-3">
                        <label className="form-lablel">Введите e-mail:</label>
                        <input className="form-control" type="text"/>
                    </div>
                </form>
            </div>
            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => { props.addContact() }}
                >
                    Добавить контакт
                </button>
            </div>
        </div>
    );
}

export default FormContact;