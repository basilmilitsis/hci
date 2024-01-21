// Ideally this should be generated from the backend API schema
// For now, it is manually created


export type VisitDto = {
    id?: number;
    hospitalId?: number;
    patientId?: number;
    doctorId?: number;
    date?: string;
    patientName?: string | null;
    hospitalName?: string | null;
    doctorName?: string | null;
    description?: string | null;
    diagnosis?: string | null;
    therapy?: string | null;
    notes?: string | null;
    medications?: string | null;
    tests?: string | null;
    recommendations?: string | null;
};

export type VisitResponse = {
    visits?: VisitDto[] | null;
};

