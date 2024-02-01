import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faHeart } from "@fortawesome/free-solid-svg-icons"
import "../css/Content.css"

function FactItem({ number, story, description, isLiked = false, likeFactHandler}: FactItemType) {
    return (
        <div>
            <div className="circle">{number}</div>

            {isLiked ? (
                <FontAwesomeIcon className="liked" icon={faHeart} />
            ) : (
                <button onClick={()=>likeFactHandler(number)} className="like-btn">
                    <FontAwesomeIcon className="liked" icon={faHeart} />
                </button>
            )
            }

            <h3 className="fact-title">{story}</h3>
            <p className="fact">{description}</p>
            <div>
                <h1 style={{ backgroundColor: "black", color: "pink" }}>
                    My Awesome App
                </h1>
                <p>My awesome app is a React app.</p>
            </div>
        </div>
    )
}

export interface FactItemType {
    number: number;
    story: string;
    description: string;
    isLiked?: boolean;
    likeFactHandler: (number:number) => void;
}

export default FactItem;