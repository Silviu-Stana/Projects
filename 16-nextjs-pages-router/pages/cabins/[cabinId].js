import CabinView from '@/components/CabinView';
import { getCabin, getCabins } from '@/lib/data-service';
import Head from 'next/head';
import { useRouter } from 'next/router';

export async function getStaticPaths() {
      // Get the paths we want to pre-render based on cabins
      const cabins = await getCabins();
      const paths = cabins.map((cabin) => ({
            params: {
                  cabinId: cabin.id.toString(),
            },
      }));

      //This log will show me which pages are statically generated:
      // console.log(paths);

      //fallback: means other routes should be rendered as fallback.
      return { paths, fallback: true };
}

export async function getStaticProps({ params }) {
      const cabin = await getCabin(params.cabinId);
      return { props: { cabin } };
}

// export async function getServerSideProps({ params }) {
//       const cabin = await getCabin(params.cabinId);
//       return { props: { cabin } };
// }

//This is how we could turn id pages back to static ->
//getStaticPaths + getStaticProps

function Cabin({ cabin }) {
      const router = useRouter();

      // If page not yet generated, show "Loading" until getStaticProps starts running.
      if (router.isFallback) return <div>Loading...</div>;

      return (
            <>
                  <Head>
                        {/* <title>Cabin #{router.query.cabinId} / The Wild Oasis</title> */}
                        <title>Cabin #{cabin.name} / The Wild Oasis</title>
                  </Head>

                  <div className="max-w-6xl mx-auto mt-8">
                        <CabinView cabin={cabin} />
                  </div>
            </>
      );
}

export default Cabin;
