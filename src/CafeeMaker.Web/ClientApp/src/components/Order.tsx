import React, {useState, useEffect, ChangeEvent} from "react";
import {DrinkIngredient, getDrinkIngredients, Mug} from "../services/drinkService";
import {useParams} from "react-router";
import {postOrder} from "../services/orderService";
import classNames from "classnames";
import {getPreference} from "../services/preferenceService";
import "./Ingredient.scss";
import {useHistory} from "react-router-dom";

const editableIngredients = ["Sucre"];

export const Order = () => {
    const {drinkId} = useParams();
    const [ingredients, setIngredients] = useState<DrinkIngredient[]>([]);
    const [isLoading, setIsLoading] = useState(true);
    const [sugarValue, setSugarValue] = useState();
    const [mugValue, setMugValue] = useState(Mug.small);
    const history = useHistory();

    useEffect(() => {
        (async () => {
            let baseIngredients = await getDrinkIngredients(drinkId);
            
            try {
                const preferences = await getPreference(drinkId);
                if (preferences) {
                    baseIngredients = baseIngredients.map(e => {
                        const p = preferences.amounts.find(p => p.drinkIngredientId === e.drinkIngredientId);
                        return {
                            ...e,
                            amount: p ? p.amount : e.amount
                        };
                    });
                    setMugValue(preferences.mug);
                }
            }
            catch {}
            
            setIngredients(baseIngredients);
            setIsLoading(false);
        })();
    }, []);

    function onSugarChange(e: ChangeEvent<HTMLInputElement>) {
        if (e.target.value.length > 3) return;
        setSugarValue(e.target.value);
    }

    const onMugClick = (e: ChangeEvent<HTMLInputElement>) => {
        setMugValue(parseInt(e.target.value, 10) as Mug);
    }

    const onStartClick = async () => {
        const amounts = ingredients.map(i => ({ 
            drinkIngredientId: i.drinkIngredientId, 
            amount: i.ingredient.name === 'Sucre' ? sugarValue : i.amount 
        }));
        
        await postOrder({
            drinkId: parseInt(drinkId, 10),
            amounts,
            mug: mugValue
        });
        
        history.push("/enjoy");
    }

    return (
        <div className="h-100 d-flex justify-content-center align-items-center">
            <div className="card w-75 mb-5">
                {isLoading ? <p>Loading</p> :
                    <div className="card-body">
                        <h2>Ingrédients</h2>
                        <hr/>
                        <form>
                            {
                                ingredients.map((ingredient) => (
                                    <div className="form-group row" key={ingredient.drinkIngredientId}>
                                        <label
                                            className="col-sm-2 col-form-label font-weight-bold">{ingredient.ingredient.name}</label>
                                        <div className="col-sm-10">
                                            {editableIngredients.indexOf(ingredient.ingredient.name) !== -1
                                                ? <input className="form-control"
                                                         type="number"
                                                         value={sugarValue ?? ingredient.amount}
                                                         onChange={onSugarChange}
                                                         required/>
                                                : <span
                                                    className="font-italic"> ({ingredient.amount.toString()} mls)</span>
                                            }
                                        </div>
                                    </div>
                                ))
                            }
                            <div className="form-group row">
                                <label className="col-sm-2 col-form-label font-weight-bold">Taille</label>
                                <div className="col-sm-10">
                                    <div className="button-group-control btn-group btn-group-toggle"
                                         data-toggle="buttons">
                                        <label className={classNames("btn", "btn-secondary", { "active": mugValue == Mug.small })}>
                                            <input type="radio" name="options" value={Mug.small} id="option1"
                                                   onChange={onMugClick}
                                            /> Petite
                                        </label>
                                        <label className={classNames("btn", "btn-secondary", { "active": mugValue == Mug.medium })}>
                                            <input type="radio" name="options" value={Mug.medium} onChange={onMugClick}
                                                   id="option2"/> Moyenne
                                        </label>
                                        <label className={classNames("btn", "btn-secondary", { "active": mugValue == Mug.large })}>
                                            <input type="radio" name="options" value={Mug.large} onChange={onMugClick}
                                                   id="option3"/> Grande
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </form>
                        <hr/>
                        <button className="btn btn-success btn-block"
                                onClick={onStartClick}>
                            Start
                        </button>
                    </div>
                }
            </div>
        </div>
    );
}
