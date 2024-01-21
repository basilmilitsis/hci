// for time making both filters a text search with an explicit search button instead of a live search

import { useState } from 'react';
import { SearchInput } from './Inputs/SearchInput';

export interface VisitFiltersProps {
    onChange: (searchPatientName: string, searchHospitalName: string) => void;
}


export const VisitFilters: React.FC<VisitFiltersProps> = ({ onChange }) => {

    const [searchPatientName, setSearchPatientName] = useState<string>("");
    const [searchHospitalName, setSearchHospitalName] = useState<string>("");

    return (
        <>
            <SearchInput
                placeholder="Search by patient name..."
                onChange={(searchText) => {
                    setSearchPatientName(searchText)
                }}
            />
            <SearchInput
                placeholder="Search by hospital name..."
                onChange={(searchText) => {
                    setSearchHospitalName(searchText)
                }}
            />

            <button
                className="bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded max-w-20"
                type="button"
                onClick={() => onChange(searchPatientName, searchHospitalName)}
            >
                Search
            </button>
        </>
    )
}