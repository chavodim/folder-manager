import { useState } from "react"
import FactItem from "./FactItem"

function FactsList({ factsData }: Facts) {
    const [facts, updateFacts] = useState(factsData)

    const likeFactHandler = (number:number) => {
        // If there is not Fact with the passed number
        if (!facts.some(fact => fact.number === number)){
            return;
        }
        const updatedFacts = facts.map((fact) => {
            if(fact.number === number){
                return { ...fact, isLiked: !fact.isLiked}
            }
            return fact;
        })
        updateFacts(updatedFacts)
    } 

    return (
        <div>
            {facts.map((fact) => {
                const factWithClick = { ...fact, likeFactHandler}
                return <FactItem key={fact.number} {...factWithClick} /> 
            })}
        </div>
    )
}

type Facts = {
    factsData: FactsListType[];
}

type FactsListType = {
    number: number;
    story: string;
    description: string;
    isLiked?: boolean;
}

export default FactsList;