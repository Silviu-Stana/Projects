import React, { useState } from 'react';
const GuestList: React.FC = () => {
      const [name, setName] = useState('');
      const [guests, setGuests] = useState<string[]>([]);

      const onClick = () => {
            setGuests([...guests, name]);
            setName('');
      };

      return (
            <div>
                  <h3>Guest List</h3>
                  <ul>
                        {guests.map((guest) => (
                              <li key={guest}>{guest}</li>
                        ))}
                  </ul>

                  <input onChange={(e) => setName(e.target.value)} value={name} />
                  <button onClick={onClick}>Add Guest</button>
            </div>
      );
};

export default GuestList;
