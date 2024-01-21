// for time coupling the component to the api schema

import { VisitDto } from "../apiSchema/schema";
import { DateTime } from 'luxon';

export interface VisitResultsProps {
    isLoading: boolean;
    visits?: VisitDto[] | null;
}

export const VisitResults: React.FC<VisitResultsProps> = ({ isLoading, visits }) => {

    if (isLoading) return <div>Fetching posts...</div>;
    if (!visits || visits.length === 0) return <div>No Results Found</div>;

    return (
        <table className="w-full text-left table-auto text-slate-500">
            <thead>
                <tr>
                    <th>Visited On</th>
                    <th>Patient</th>
                    <th>Hospital</th>
                    <th>Doctor</th>
                </tr>
            </thead>
            <tbody>
                {
                    visits && visits && visits.map((visit) => (
                        <tr 
                            key={visit.id}
                            className="border-b dark:border-slate-300"
                        >
                            <td className="p-4 pl-8 text-slate-500">{DateTime.fromISO(visit.visitedOn).toISODate()}</td>
                            <td>{visit.patientName}</td>
                            <td>{visit.hospitalName}</td>
                            <td>{visit.doctorName}</td>
                        </tr>
                    ))
                }
            </tbody>
        </table>
    );
}