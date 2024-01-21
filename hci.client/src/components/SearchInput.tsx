
export interface SearchInputProps {
    placeholder: string;
    defaultValue: string;
    onChange: (value: string) => void;
}


export const SearchInput: React.FC<SearchInputProps> = ({ placeholder, defaultValue, onChange }: SearchInputProps) => {
    return (
        <div className="flex items-center justify-center">
            <div className="flex items-center border-b border-b-2 border-teal-500 py-2">
                <input
                    className="appearance-none bg-transparent border-none w-full text-gray-700 mr-3 py-1 px-2 leading-tight focus:outline-none"
                    type="text"
                    defaultValue={defaultValue}
                    placeholder={placeholder}
                    aria-label="Search"
                    onChange={(e) => onChange(e.target.value)}
                />
                <button
                    className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
                    type="button">

                    Search
                </button>
            </div>
        </div>
    );
}