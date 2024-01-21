// Ideally this should be generated from the backend API schema
// For now, it is manually created


export type VisitDto = {
    id: number;
    visitedOn: string;
    patientName: string | null;
    hospitalName: string | null;
    doctorName: string | null;
};

export type VisitResponse = {
    visits: VisitDto[] | null;
};

