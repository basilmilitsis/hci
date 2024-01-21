import { useState } from 'react';
import './App.css';
import { SearchInput } from './components/SearchInput';
import { useQuery } from '@tanstack/react-query';
import axios from 'axios';


interface Visit {
    id: number;
    // TODO: Add more fields here
}

function App() {
    //const [visits, setVisits] = useState<Visit[]>();
    const [searchText, setSearchText] = useState<string>("");

    const { data: visits, isLoading, error } = useQuery({
        queryKey: ['visits', searchText],
        queryFn: async () => {
            const response = await axios.get(`https://localhost:7061/api/visits/search?searchText=${searchText}`, {
                headers: {
                    'Accept': 'application/json',
                    //'Content-Type': 'application/json',
                    'Access-Control-Allow-Origin': '*'
                }
            })
            return response.data;
        },
    })


    if (isLoading) return <div>Fetching posts...</div>;
    if (error) return <div>An error occurred: {error.message}</div>;


    //const contents = visits === undefined
    //    ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
    //    : <table className="table table-striped" aria-labelledby="tabelLabel">
    //        <thead>
    //            <tr>
    //                <th>Date</th>
    //                <th>Temp. (C)</th>
    //                <th>Temp. (F)</th>
    //                <th>Summary</th>
    //            </tr>
    //        </thead>
    //        <tbody>
    //            {/*{visits.map(forecast =>*/}
    //            {/*    <tr key={forecast.date}>*/}
    //            {/*        <td>{forecast.date}</td>*/}
    //            {/*        <td>{forecast.temperatureC}</td>*/}
    //            {/*        <td>{forecast.temperatureF}</td>*/}
    //            {/*        <td>{forecast.summary}</td>*/}
    //            {/*    </tr>*/}
    //            {/*)}*/}
    //        </tbody>
    //    </table>;


    console.log(visits);

    return (
        <div>

            <h1 id="text-3xl">Visits</h1>
            <p>This component demonstrates fetching data from the server.</p>

            <SearchInput
                placeholder="Search..."
                defaultValue=""
                onChange={(searchText) => {
                    setSearchText(searchText)
                }}
            />
        </div>
    );
}

export default App;