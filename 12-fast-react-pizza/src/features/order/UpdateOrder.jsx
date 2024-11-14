import { useFetcher } from "react-router-dom";
import Button from "../../ui/Button";
import { updateOrder } from "../../services/apiRestaurant";

function UpdateOrder({ order }) {
        const fetcher = useFetcher();

        return (
                <fetcher.Form method="PATCH" className="text-right">
                        <Button type="primary">Activate priority order</Button>
                </fetcher.Form>
        );
}

export default UpdateOrder;

export async function action({ request, params }) {
        const data = { priority: true };

        //"params" come from the URL
        //without this method, we might have not had a way to update the order
        await updateOrder(params.orderId, data);

        return null;
}
