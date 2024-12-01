import Button from '../../ui/Button';
import CreateCabinForm from './CreateCabinForm';
import Window from '../../ui/Modal';
import Modal from '../../ui/Modal';

function AddCabin() {
      return (
            <div>
                  <Modal>
                        <Window.Open opens="cabin-form">
                              <Button onClick={close}>Add new cabin</Button>
                        </Window.Open>
                        <Window.Window name="cabin-form">
                              <CreateCabinForm />
                        </Window.Window>
                  </Modal>
            </div>
      );
}

// function AddCabin() {
//       const [isOpenModal, setIsModalOpen] = useState(false);

//       return (
//             <div>
//                   <Button onClick={() => setIsModalOpen(!isOpenModal)}>Add new cabin</Button>
//                   {isOpenModal && (
//                         <Modal onClose={() => setIsModalOpen(false)}>
//                               <CreateCabinForm onCloseModal={() => setIsModalOpen(false)} />
//                         </Modal>
//                   )}
//             </div>
//       );
// }

export default AddCabin;
