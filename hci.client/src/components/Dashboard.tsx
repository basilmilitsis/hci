export interface DashboardProps {
    title: string;
    children?: React.ReactNode;
    filters?: React.ReactNode;
}

export const Dashboard: React.FC<DashboardProps> = ({ title, filters, children }) => {

    return (
        <div className="flex h-screen overflow-hidden">

            {/* Sidebar */}
            <div className="sm:w-0 md:w-1/4 bg-slate-200">

            </div>

            {/* Content area */}
            <div className="relative flex flex-col flex-1 overflow-y-auto overflow-x-hidden">

                <main>
                    <div className="px-4 sm:px-6 lg:px-8 py-8 w-full max-w-9xl mx-auto">
                        {/* Title */}
                        <h1 className="text-5xl mb-8 ">
                            { title }
                        </h1>

                        {/* Filters */}
                        <div className="mb-8 grid grid-cols-1 sm:grid-cols-3 gap-4  bg-slate-100 rounded-lg px-4 py-2">
                            { filters }
                        </div>

                        {/* Content */}
                        <div className="w-full">
                            { children }
                        </div>
                    </div>
                </main>
            </div>
        </div>
    );
}