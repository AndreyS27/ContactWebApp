import { useState } from "react";

const FormContact = (props) => {

    const[contactName, setContactName] = useState("");
    const[contactEmail, setContactEmail] = useState("");

    const submit = () => {
        props.addContact(contactName, contactEmail);
    }

    return (
        <div>
            <div className="mb-3">
                <form >
                    <div className="mb-3">
                        <label className="form-lablel">Введите имя:</label>
                        <input className="form-control" type="text"
                            onChange={(e) => {setContactName(e.target.value)}}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-lablel">Введите e-mail:</label>
                        <input className="form-control" type="text"
                            onChange={(e) => {setContactEmail(e.target.value)}}
                        />
                    </div>
                </form>
            </div>
            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => { submit() }}
                >
                    Добавить контакт
                </button>
            </div>
        </div>
    );
}

export default FormContact;