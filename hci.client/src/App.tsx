import axios from 'axios';
import { useState } from 'react';
import { useQuery } from '@tanstack/react-query';
import { Dashboard } from './components/Dashboard';
import { VisitResults } from './components/VisitResults';
import { VisitFilters } from './components/VisitFilters';
import { VisitResponse } from './apiSchema/schema';

function App() {

    const [searchPatientName, setSearchPatientName] = useState<string>("");
    const [searchHospitalName, setSearchHospitalName] = useState<string>("");

    console.log("=====> ", import.meta.env);

    const { data: visitData, isLoading, error } = useQuery({
        queryKey: ['visits', searchPatientName, searchHospitalName],
        queryFn: async () => {
            const response = await axios.get(`${import.meta.env.VITE_API_BASE_URL}/api/visits/search?searchPatientName=${searchPatientName}&searchHospitalName=${searchHospitalName}`, {
                headers: {
                    'Accept': 'application/json',
                }
            })
            return response.data as VisitResponse;
        },
    })

    if (error) return <div>An error occurred: {error.message}</div>;

    return (
        <Dashboard
            title="Visits"
            filters={<>
                <VisitFilters onChange={(searchPatientName, searchHospitalName) => {
                    setSearchPatientName(searchPatientName);
                    setSearchHospitalName(searchHospitalName);
                }} />
            </>}
        >
            <VisitResults isLoading={isLoading} visits={visitData?.visits} />
        </Dashboard>
    );
}
export default App;
