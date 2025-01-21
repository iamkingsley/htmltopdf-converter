import './App.css'
import {UploadPage} from "@/features/file-upload/UploadPage.tsx";
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";

function App() {
  const queryClient = new QueryClient();
  return (
      <QueryClientProvider client={queryClient}>
        <UploadPage />
      </QueryClientProvider>
  )
}

export default App
