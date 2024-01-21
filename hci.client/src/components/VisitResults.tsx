// for time coupling the component to the api schema

import { VisitDto } from "../apiSchema/schema";

export interface VisitResultsProps {
    isLoading: boolean;
    visits?: VisitDto[] | null;
}

export const VisitResults: React.FC<VisitResultsProps> = ({ isLoading, visits }) => {

    if (isLoading) return <div>Fetching posts...</div>;
    if (!visits || visits.length === 0) return <div>Not Results Found</div>;

    return (
        <table className="w-full text-left table-auto text-slate-600">
            <thead>
                <tr>
                    <th>Visit</th>
                    <th>Patient</th>
                    <th>Hospital</th>
                </tr>
            </thead>
            <tbody>
                {
                    visits && visits && visits.map((visit) => (
                        <tr className="border-b dark:border-slate-600">
                            <td className="p-4 pl-8 text-slate-500">{visit.id}</td>
                            <td>{visit.patientName}</td>
                            <td>{visit.hospitalName}</td>
                        </tr>
                    ))
                }
            </tbody>
        </table>
    );
}