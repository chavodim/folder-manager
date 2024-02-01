function Header(props:HeaderProps) {
    return (
        <header>
            <h1>{props.children}</h1>
        </header>
    )
}

//The other option was React.ReactElement, but it is more limiting to a single element
type HeaderProps = {
    children: React.ReactNode;
}

export default Header;