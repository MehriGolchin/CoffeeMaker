import {post} from "./HttpClient"
import {API_BASE_URI} from "../constants";
import {Mug} from "./drinkService";

export interface OrderRequest {
    readonly drinkId: number;
    readonly amounts: { drinkIngredientId: number, amount: number }[],
    readonly mug: Mug;
}

export async function postOrder(request: OrderRequest) {
    const url = new URL('order', API_BASE_URI);
    return await post<any>(url, request);
}