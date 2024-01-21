export interface SearchInputProps {
    placeholder: string;
    onChange: (value: string) => void;
}

export const SearchInput: React.FC<SearchInputProps> = ({ placeholder, onChange }: SearchInputProps) => {
    return (
        <div className="flex items-center border-b border-b-2 border-teal-500 py-2">
            <input
                className="appearance-none bg-transparent border-none w-full text-gray-700 mr-3 py-1 px-2 leading-tight focus:outline-none"
                type="text"
                placeholder={placeholder}
                aria-label="Search"
                onChange={(e) => onChange(e.target.value)}
            />
        </div>
    );
}