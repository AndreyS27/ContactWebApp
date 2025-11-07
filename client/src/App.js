import axios from "axios";
import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/TableContact/TableContact";
import { useState, useEffect } from "react";
import { Route, Routes, useLocation } from "react-router-dom";
import ContactDetails from "./layout/ContactDetails/ContactDetails";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const [contacts, setContacts] = useState([]);
  const location = useLocation();

  
  useEffect(() => {
    const url = `${baseApiUrl}/ContactManagement/contacts`;
    axios.get(url).then(
      res => setContacts(res.data)
    );
  }, [location.pathname]);

  const addContact = (contactName, contactEmail) => {
    const newId = contacts.length === 0 ? 1 : Math.max(
      ...contacts.map(e => e.id)) + 1;

    const item = {
      id: newId,
      name: contactName,
      email: contactEmail
    };

    const url = `${baseApiUrl}/ContactManagement/contacts`;
    axios.post(url, item);
    setContacts([...contacts, item]);
  }

  return (
    <div className="container mt-5">
      <Routes>
        <Route path="/" element={
          <div className="card">
            <div className="card-header">
              <h1>Список контактов</h1>
            </div>

            <div className="card-body">
              <TableContact
                contacts={contacts}
              />
              <FormContact addContact={addContact} />
            </div>
          </div>
        } />
        <Route path="contact/:id" element={<ContactDetails />} />
      </Routes>
    </div>
  );
}

export default App;
