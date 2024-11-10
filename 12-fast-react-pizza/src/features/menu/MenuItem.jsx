import Button from "../../ui/Button";
import { formatCurrency } from "../../utils/helpers";

function MenuItem({ pizza }) {
        const { id, name, unitPrice, ingredients, soldOut, imageUrl } = pizza;

        return (
                <li className="flex gap-4 py-2">
                        <img src={imageUrl} alt={name} className={`${soldOut ? "opacity-70 grayscale" : ""} h-24 rounded-md`} />
                        <div className="flex grow flex-col pt-0.5">
                                <p className="font-medium">{name}</p>
                                <p className="text-sm capitalize italic text-stone-500">{ingredients.join(", ")}</p>
                                <div className="items-be mt-auto flex items-center justify-between">
                                        {!soldOut ? <p className="text-sm">{formatCurrency(unitPrice)}</p> : <p className="text-sm font-medium uppercase text-stone-500">Sold out</p>}

                                        <Button type="small">Add to cart</Button>
                                </div>
                        </div>
                </li>
        );
}

export default MenuItem;